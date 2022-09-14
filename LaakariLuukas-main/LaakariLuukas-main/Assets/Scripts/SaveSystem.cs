using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //Polku tiedostoon, joka sisältää tallennetut tiedot. persistentDataPath varmistaa, että polku toimii kaikilla käyttöjärjestelmillä.
    public static string path = Application.persistentDataPath + "/GameData.dat";

    public static void SaveGame(TimerScript ts)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Create); //Avataan "tietoyhteys" tallennustiedostoon

        GameData data = new GameData(ts); //Tehdään uusi instanssi GameData luokasta, jolle syötämme meille syötetyn TimerScriptin tiedot tallennusta varten
        bf.Serialize(fs, data); //Kirjoitetaan GameDatan tiedot tiedostoon käyttäen tietoyhteyttä
        fs.Close();
    }

    public static GameData LoadGame()
    {
        if(File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open); //Avataan "tietoyhteys" tallennustiedostoon

            GameData data = bf.Deserialize(fs) as GameData; //Nostetaan tallennetut tiedot tiedostosta yhteyttä käyttäen ja asetetaan ne muuttujaan data
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
