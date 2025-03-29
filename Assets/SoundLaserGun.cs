using UnityEngine;

public class SoundGun : MonoBehaviour
{
    // ���ҧ����� AudioSource �����纡��������§
    private AudioSource gunAudioSource;

    // ����������§�׹
    public AudioClip gunShotSound;

    void Start()
    {
        // �� Component AudioSource �ҡ GameObject ���
        gunAudioSource = GetComponent<AudioSource>();

        // ��˹����������§��������Ҩҡ������§�׹����˹�
        gunAudioSource.clip = gunShotSound;
    }

    void Update()
    {
        // ����͡����� Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���¡�ѧ���� Play ����������§�׹
            PlayGunShotSound();
        }
    }

    // �ѧ����������§�׹
    private void PlayGunShotSound()
    {
        // ��Ǩ�ͺ��� AudioSource ��������������� ���������§�׹
        if (gunAudioSource != null)
        {
            gunAudioSource.Play();
        }
    }
}