using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class SaveManager
{
    private static readonly string SaveFilePath = "save.json";

    // 게임 데이터를 JSON으로 저장
    public static void SaveGame()
    {
        // PlayerData 객체에 현재 플레이어 상태를 담는다
        var playerDto = new PlayerData
        {
            Name = Player.Name,
            Job = Player.Job,
            Level = Player.Level,
            Exp = Player.Exp,
            Hp = Player.Hp,
            MaxHp = Player.MaxHp,
            Atk = (int)Player.Atk,
            Def = (int)Player.Def,
            Gold = Player.Gold
        };

        // Inventory에 보유 중인 아이템들만 DTO로 변환
        var inventoryDto = Item.AllItems
            .Where(item => item.IsOccupied)
            .Select(item => new ItemData
            {
                Name = item.Name,
                Type = item.Type,
                Atk = item.Atk,
                Def = item.Def,
                Description = item.Description,
                Price = item.Price,
                IsEquipped = item.IsEquipped,
                IsOccupied = item.IsOccupied
            })
            .ToList();

        // 최종 저장 구조체
        var saveData = new SaveData
        {
            player = playerDto,
            Inventory = inventoryDto
        };

        // JSON 직렬화(들여쓰기)
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };
        string json = JsonSerializer.Serialize(saveData, options);

        // 파일에 쓰기 (없으면 생성, 있으면 덮어쓰기)
        File.WriteAllText(SaveFilePath, json);
    }

    // 저장된 JSON을 읽어와 게임 상태를 복원
    public static bool LoadGame()
    {
        if (!File.Exists(SaveFilePath))
            return false;  // 저장 파일이 없으면 로드 실패

        string json = File.ReadAllText(SaveFilePath);
        var saveData = JsonSerializer.Deserialize<SaveData>(json);
        if (saveData == null)
            return false;

        // Player 상태 복원
        var pd = saveData.player;
        Player.Name = pd.Name;
        Player.Job = pd.Job;
        Player.Level = pd.Level;
        Player.Exp = pd.Exp;
        Player.Hp = pd.Hp;
        Player.MaxHp = pd.MaxHp;
        Player.Atk = pd.Atk;
        Player.Def = pd.Def;
        Player.Gold = pd.Gold;

        // Inventory 초기화 후, 저장된 아이템들만 적용
        foreach (var item in Item.AllItems)
        {
            item.IsOccupied = false;
            item.IsEquipped = false;
        }

        foreach (var id in saveData.Inventory)
        {
            var item = Item.AllItems.FirstOrDefault(x => x.Name == id.Name);
            if (item != null)
            {
                item.IsOccupied = true;
                item.IsEquipped = id.IsEquipped;
            }
        }

        // Inventory 리스트 갱신
        Inventory.renew();

        return true;
    }
}
