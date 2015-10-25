using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public float hitPoints = 100f;
	public float currentHitPoints;

  // [SerializeField] private NetworkManager networkManager;


	// Use this for initialization
	void Start () {
		currentHitPoints = hitPoints;
      //  networkManager = new NetworkManager();
	}

	[RPC]
	public void TakeDamage(float amt) {
		currentHitPoints -= amt;

		if(currentHitPoints <= 0) {
			Die();
		}
	}

    void Update()
    {
        currentHitPoints = currentHitPoints;
        KillforTall();
    }

    void KillforTall()
    {
        if (this.transform.position.y < -30)
        {
            NetworkManager nm = GameObject.FindObjectOfType<NetworkManager>();
            nm.AddChatMessage(PhotonNetwork.player.name + " se matou!");
           // networkManager.AddChatMessage(PhotonNetwork.player.name + " se matou");
            Die();
            
        }
    }
	/*void OnGUI() {
		if( GetComponent<PhotonView>().isMine && gameObject.tag == "Player" ) {
			if( GUI.Button(new Rect (Screen.width-100, 0, 100, 40), "Suicide!") ) {
				Die ();
			}
		}
	}*/

	 void Die() {
		if( GetComponent<PhotonView>().instantiationId==0 ) {
			Destroy(gameObject);
		}
		else {
			if( GetComponent<PhotonView>().isMine ) {
				if( gameObject.tag == "Player" ) {		// This is my actual PLAYER object, then initiate the respawn process
					NetworkManager nm = GameObject.FindObjectOfType<NetworkManager>();
                    nm.AddChatMessage(PhotonNetwork.player.name + " foi morto!");
					nm.standbyCamera.SetActive(true);
					nm.respawnTimer = 3f;
				}
				else if( gameObject.tag == "Bot" ) {
					Debug.LogError("WARNING: No bot respawn code exists!");
				}

				PhotonNetwork.Destroy(gameObject);
			}
		}
	}
}
