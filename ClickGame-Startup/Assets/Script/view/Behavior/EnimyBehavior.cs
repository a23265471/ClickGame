using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MeshFader))]
[RequireComponent(typeof(AudioSource))]

public class EnimyBehavior : MonoBehaviour {

    private Animator animator;
    private MeshFader meshFader;
    private AudioSource audioSource;
    private HealthComponent healthComponent;

    [SerializeField]
    private AudioClip hurtClip;
    public AudioClip deadClip;
    public Enemydata enemyData;

    public bool IsDead
    {
        get
        {
            return healthComponent.IsOver;
        }

    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        meshFader = GetComponent<MeshFader>();
        audioSource = GetComponent<AudioSource>();
        healthComponent = GetComponent<HealthComponent>();
        
    }
    
    private void OnEnable()
    {
        StartCoroutine(meshFader.FadeIn());
        healthComponent.Init(100);
    }

    [ContextMenu("Test Execute")]
    private void TestExecute()
    {
        StartCoroutine(Execute(enemyData));
    }

    public IEnumerator Execute(Enemydata enemyData)
    {
        healthComponent.Init(enemyData.health);
        while (IsDead == false)
        {
            yield return null;
        }
        animator.SetTrigger("die");
        audioSource.clip = deadClip;
        audioSource.Play();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        yield return StartCoroutine(meshFader.FadeOut());
    }

    private void DoDamage(int attack)
    {
        animator.SetTrigger("hurt");
        audioSource.clip = hurtClip;
        audioSource.Play();
        healthComponent.Hurt(attack);
    }

    private void Update()
    {
        if (healthComponent.IsOver)
            return;
        if (Input.GetButtonDown("Fire1"))
        {
            DoDamage(20);
        }

    }
}
