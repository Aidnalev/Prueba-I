using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeAnimaciones : MonoBehaviour
{
    public static string currentAnimation = null;
    public void House()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("House D");
        currentAnimation = "House D";
    }

    public void Macarena()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Macarena");
        currentAnimation = "Macarena";
    }

    public void HipHop()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Hip Hop");
        currentAnimation = "Hip Hop";
    }

    public void Seguir()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
