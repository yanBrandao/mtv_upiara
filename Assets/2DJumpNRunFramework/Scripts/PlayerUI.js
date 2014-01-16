#pragma strict

private var health_js : PlayerHealth;
private var cam_js : PlayerCamera;
function Start()
{
	health_js = GetComponent(PlayerHealth) as PlayerHealth;
	cam_js = GetComponent(PlayerCamera) as PlayerCamera;
}

function Update () {
}