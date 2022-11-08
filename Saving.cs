using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HashtagGenerator
{
    public static class Saving
    {
        static private readonly string SAVE_FILE_PATH_HASHTAGS = "hashtags.hg";
        static private JsonSerializerOptions options = new JsonSerializerOptions
        {
            IncludeFields = true,
            WriteIndented = true
        };

        public static void Save(List<string> hashtags)
        {
            // Serialize it to JSON
            string json = JsonSerializer.Serialize(hashtags, options);

            // Save it to a file
            File.WriteAllText(SAVE_FILE_PATH_HASHTAGS, json);
        }

        public static List<string> Load()
        {
            List<string> hashtagsLoaded = new List<string>();

            if (!File.Exists(SAVE_FILE_PATH_HASHTAGS))
                return hashtagsLoaded;

            string json = File.ReadAllText(SAVE_FILE_PATH_HASHTAGS);
            hashtagsLoaded = JsonSerializer.Deserialize<List<string>>(json, options)!;
            return hashtagsLoaded;
        }
    }
}
