using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Game
{
    public class Loader
    {
        private const string FileName = "/SaveData.dat";
        public void Save(GameModel gameModel)
        {
            using (FileStream file =
                   new FileStream(Application.persistentDataPath + FileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, gameModel);
                file.Close();
            }
        }

        public GameModel TryLoad()
        {
            if (!File.Exists(Application.persistentDataPath + FileName))
                return null;
            GameModel gameModel;
            using (FileStream file =
                   new FileStream(Application.persistentDataPath + FileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                gameModel = formatter.Deserialize(file) as GameModel;
                file.Close();
            }

            return gameModel;
        }
    }
}