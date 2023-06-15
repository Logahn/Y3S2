package Labwork5;

public class Main {

    public static void main(String[] args) {

        CassettePlayer cassettePlayer = new CassettePlayer();

        CassettePlayerAdapter adapter = new CassettePlayerAdapter(cassettePlayer);

        Person person = new Person();

        person.PlayTrack(adapter, "Track 1");
    }

}
