using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayFabLogin : MonoBehaviour
{
    //Declaramos objetos de tipo InputField
    public InputField inp_email;
    public InputField inp_password;
    public InputField inp_email_registro;
    public InputField inp_password_registro;
    //Declaramos variable para controlar panel login 
    public GameObject panelLogin;
    //Declaramos variable para controlar panel de registro
    public GameObject panelRegistro;
    //Declaramos variable para controlar panel de login error
    public GameObject panelLoginError;

    void Start()
    {
        // LoginEmail();
    }
    public void LoginEmail()
    {
        //Extraemos el texto de la entrada de email
        string user_email = inp_email.text;
        //Extraemos el texto de la entrada de password
        string user_password = inp_password.text;

        var request = new LoginWithEmailAddressRequest { Email = user_email, Password = user_password };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        //Debug.Log("Login correcto");
        SceneManager.LoadScene("Scenes/MainScene");

    }

    private void OnLoginFailure(PlayFabError error)
    {
        //Ocultamos panel de login
        panelLogin.SetActive(false);
        //Mostramos panel de login error
        panelLoginError.SetActive(true);
        Debug.Log("Acceso incorrecto");
        Debug.LogError(error.GenerateErrorReport());
    }
    //Método para panel de error
    public void ocultarPanelError()
    {
        //Ocultamos panel de login error
        panelLoginError.SetActive(false);
        //Mostramos panel de login 
        panelLogin.SetActive(true);
    }
    // Metodo para ocultar registro
    public void ocultarPanelogin()
    {
        //Ocultamos panel de login
        panelLogin.SetActive(false);
        panelRegistro.SetActive(true);
    }
    // Método para registrar usuario
    public void Register()
    {
        // Extraemos el texto de las entradas de registro
        string user_email = inp_email_registro.text;
        string user_password = inp_password_registro.text;

        var request = new RegisterPlayFabUserRequest { Email = user_email, Password = user_password, RequireBothUsernameAndEmail = false };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registro exitoso");
        panelRegistro.SetActive(false); // Ocultar el panel de registro
        panelLogin.SetActive(true); // Mostrar el panel de login
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        // Mostrar error de registro
        panelRegistro.SetActive(true);
        Debug.Log("Error en registro");
        Debug.LogError(error.GenerateErrorReport());
    }
}