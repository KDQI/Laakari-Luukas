using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //Polku tiedostoon, joka sis�lt�� tallennetut tiedot. persistentDataPath varmistaa, ett� polku toimii kaikilla k�ytt�j�rjestelmill�.
    public static string path = Application.persistentDataPath + "/GameData.dat";

    public static void SaveGame(TimerScript ts)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Create); //Avataan "tietoyhteys" tallennustiedostoon

        GameData data = new GameData(ts); //Tehd��n uusi instanssi GameData luokasta, jolle sy�t�mme meille sy�tetyn TimerScriptin tiedot tallennusta varten
        bf.Serialize(fs, data); //Kirjoitetaan GameDatan tiedot tiedostoon k�ytt�en tietoyhteytt�
        fs.Close();
    }

    public static GameData LoadGame()
    {
        if(File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open); //Avataan "tietoyhteys" tallennustiedostoon

            GameData data = bf.Deserialize(fs) as GameData; //Nostetaan tallennetut tiedot tiedostosta yhteytt� k�ytt�en ja asetetaan ne muuttujaan data
            fs.Close();
            return data; //Palautetaan data muuttuja funktion kutsuneelle luokalle
        } else
        {
            Debug.LogError("No SaveFile found!");
            return null;
        }
    }

    public static void DeleteSaveFile()
    {
        File.Delete(path);
    }
}
