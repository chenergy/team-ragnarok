using UnityEngine;
using System.Collections;
using FightGame;

public class HitBoxInput : MonoBehaviour
{
	[HideInInspector]
	public HitBox hitbox;
	
	void OnTriggerEnter( Collider other ){
		//Debug.Log(hitbox.gobj.name + " is Colliding with " + other.gameObject.name);
		if (other.tag == "HurtBox"){
			HurtBox hurtbox = other.GetComponent<HurtBoxInput>().hurtbox;
			if (hurtbox.attackOwner.playerNumber != this.hitbox.attackOwner.playerNumber){
				if (hurtbox.attackOwner.CurrentState != "knockDown"){
					hurtbox.attackOwner.TakeDamage(this.hitbox.damage * this.hitbox.attackOwner.extraDamage, hurtbox, this.hitbox.knockback, this.hitbox.canKnockDown);
					this.hitbox.Disable();
					if (this.hitbox.onCollisionSound != null){
						GameManager.PlayAudio( this.hitbox.onCollisionSound, 1.0f );
					}
					if (this.hitbox.isProjectile){
						GameObject.Destroy(this.transform.parent.gameObject);
					}
				}
			}
		}
		
		else if (other.tag == "HitBox"){
			HitBox otherHitbox = other.GetComponent<HitBoxInput>().hitbox;
			if (otherHitbox.attackOwner.playerNumber != this.hitbox.attackOwner.playerNumber){
				if (this.hitbox.isProjectile && (this.tag != "SuperHitBox") && otherHitbox.isProjectile){
					GameObject.Destroy(this.transform.parent.gameObject);
				}
			}
		}
		
		else if (other.tag == "SuperHitBox"){
			HitBox otherHitbox = other.GetComponent<HitBoxInput>().hitbox;
			if (otherHitbox.attackOwner.playerNumber != this.hitbox.attackOwner.playerNumber){
				if (this.hitbox.isProjectile){
					GameObject.Destroy(this.transform.parent.gameObject);
				}
			}
		}
	}
}

