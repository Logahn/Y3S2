package Labwork5;

// iPlayer interface
interface iPlayer {
    void Play(String trackName);
}

// CassettePlayer class
class CassettePlayer implements iPlayer {
    private String currentTrack;

    public void SetTrack(String trackName) {
        currentTrack = trackName;
    }

    public void Play() {
        System.out.println("Playing " + currentTrack);
    }

    public void Play(String trackName) {
        SetTrack(trackName);
        Play();
    }
}

// Adapter class
class CassettePlayerAdapter implements iPlayer {
    private CassettePlayer cassettePlayer;

    public CassettePlayerAdapter(CassettePlayer cassettePlayer) {
        this.cassettePlayer = cassettePlayer;
    }

    public void Play(String trackName) {
        cassettePlayer.SetTrack(trackName);
        cassettePlayer.Play();
    }
}

// Person class
class Person {
    public void PlayTrack(iPlayer player, String trackName) {
        player.Play(trackName);
    }
}