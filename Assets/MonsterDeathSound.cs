using UnityEngine;

public class MonsterDeathSound : MonoBehaviour
{

    public AudioClip deathSound; // ������§����ͧ������������͹�������
    private AudioSource audioSource;

    void Start()
    {

        // ���� AudioSource ŧ㹵���͹����� �ҡ�����
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // ������������§�ѵ��ѵ�

    }

    public void PlayDeathSound()
    {

        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound); // ������§�͹�������
        }
        else
        {
            Debug.LogWarning("�����������§����Ѻ�͹�������!");
        }

     







    }
}
