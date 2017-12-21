//The only functions that the client side needs to use are the static ones
//GetTrust(ID) and ChangeTrust(ID, change)
//Set inital parameters for the NPCS in the static constructor
public class NPCTrust
{
	private int trust; //the amount this NPC trusts the PC
	private int[] influences; //the influence this NPC has over others (-2 to 2)

	private static NPCTrust[] NPCS; //static array of all the NPCs

	private NPCTrust(int trust, int[] influences)
	{ //normal constructor
		if (influences.Length != NPCS.Length)
			throw new System.ArgumentException("length of influences must be length of NPCS", "influences");
		this.influences = influences;
		this.trust = trust;
	}

	static NPCTrust()
	{ //when NPCS is first called this should trigger and create NPCS
		NPCS = new NPCTrust[5];
		NPCS[0] = new NPCTrust(1, new int[] { 0, 0, 2, -2, 1 });
		NPCS[1] = new NPCTrust(-2, new int[] { 1, -1, 0, 0, 1 });
		NPCS[2] = new NPCTrust(-1, new int[] { 2, 0, 2, -2, 0 });
		NPCS[3] = new NPCTrust(2, new int[] { -1, 1, 0, -2, 1 });
		NPCS[4] = new NPCTrust(4, new int[] { 0, 2, -1, -1, 0 });
	}

	private void ChangeTrust(int change)
	{
		if (change != 0)
		{ //if the change isn't 0
			trust += change; //change this NPC's trust

			if (trust > 5) //keep it from -5 to 5
				trust = 5;
			if (trust < -5)
				trust = -5;

			for (int i = 0; i < influences.Length; i++)
			{ //for everyone in the influences array
				int influence = (int) (influences[i] * change * 0.25); //the amount of influence is .25*original change * amount of influence
				NPCS[i].ChangeTrust(influence); //call changeTrust on that NPC
			}
		}
	}

	public static void ChangeTrust(int personID, int change) //for client
	{
		NPCS[personID].ChangeTrust(change);
//		Debug.WriteLine("Changing person " + personID + " by " + change); //for debugging
	}

	private int GetTrust()
	{
		return trust;
	}

	public static int GetTrust(int personID) //for client
	{
		return NPCS[personID].GetTrust();
	}

//	public static void PrintAllTrusts() //for debugging
//	{
//		for (int i = 0; i < NPCS.Length; i++)
//		{
//			Debug.Write( GetTrust(i)+" , ");
//		}
//	}

//	static void Main(string[] args)
//	{
//		PrintAllTrusts();
//		ChangeTrust(4,2);
//		PrintAllTrusts();
//		ChangeTrust(0, -2);
//		PrintAllTrusts();
//		ChangeTrust(2, -1);
//		PrintAllTrusts();
//	}
}