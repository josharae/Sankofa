using UnityEngine;
using System.Collections.Generic;

public class Oware_Script_DeathAI : MonoBehaviour {

	private List<List<Transform>> DeathMarbles = new List<List<Transform>>();
	private List<List<Transform>> PlayerMarbles = new List<List<Transform>>();
	Oware_Script_Game osg;

	// Use this for initialization
	void Start () {
		osg = GetComponent<Oware_Script_Game> ();
		for (int i = 6; i < 12; i++) {
			DeathMarbles.Add(osg.groups[i]);
		}
		for (int j = 0; j < 6; j++) {
			PlayerMarbles.Add(osg.groups[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!osg.isPlayerTurn) {
			if (!osg.isMoving && !osg.isCollecting){
				List<Transform> nextMove = FindBestOption();
				if (nextMove != null){
					if (nextMove == osg.b1children){
						osg.MoveB1();
					}
					else if (nextMove == osg.b2children){
						osg.MoveB2();
					}
					else if (nextMove == osg.b3children){
						osg.MoveB3();
					}
					else if (nextMove == osg.b4children){
						osg.MoveB4();
					}
					else if (nextMove == osg.b5children){
						osg.MoveB5();
					}
					else if (nextMove == osg.b6children){
						osg.MoveB6();
					}
				}
			}
		}
	}

	public List<List<Transform>> GetPossibleBoard(List<Transform> nextMove){
		int size = nextMove.Count;
		int index = osg.groups.IndexOf (nextMove);
		List<List<Transform>> newBoard = osg.groups;
		for (int i = index; i < size + index; i++) {
			if (i < 11){
				newBoard[i+1].Add(nextMove[i]);
			}
			else if (i >= 11 && i < 23) {
				newBoard[i-11].Add(nextMove[i]);
			}
			else if (i>= 23 && i < 35) {
				newBoard[i-23].Add(nextMove[i]);
			}
			else if (i >= 35 && i < 47){
				newBoard[i-33].Add(nextMove[i]);
			}
			else {
				newBoard[i-47].Add(nextMove[i]);
			}
		}
		return newBoard;
	}

	public int GetPossibleScore(List<List<Transform>> possibleBoard, List<Transform> nextMove){
		int size = nextMove.Count;
		int index = osg.groups.IndexOf (nextMove);
		int finalIndex = size + index;
		int possibleScore = 0;
		List<Transform> endPosition;
		if (finalIndex < 12){
			endPosition = possibleBoard[finalIndex];
		}
		else if (finalIndex >= 12 && finalIndex < 24) {
			endPosition = possibleBoard[finalIndex - 12];
		}
		else if (finalIndex >= 24 && finalIndex < 36) {
			endPosition = possibleBoard[finalIndex - 24];
		}
		else if (finalIndex >= 36 && finalIndex < 48){
			endPosition = possibleBoard[finalIndex - 36];
		}
		else {
			endPosition = possibleBoard[finalIndex - 48];
		}
		bool canCollect = true;
		while (finalIndex >= 0 && finalIndex < 6 && canCollect){
			if (endPosition.Count == 2) {
				possibleScore += 2;
			} else if (endPosition.Count == 3) {
				possibleScore += 3;
			} else {
				canCollect = false;
			}
			finalIndex--;
		}
		return possibleScore;
	}

	public List<Transform> FindBestOption(){
		List<Transform> nextMove;
		int bestScore = 0;
		for (int i = 6; i < 12; i++) {
			List<Transform> list = osg.groups[i];
			List<List<Transform>> possibleBoard = GetPossibleBoard(list);
			int possibleScore = GetPossibleScore(possibleBoard, list);
			if (possibleScore > bestScore){
				bestScore = possibleScore;
				nextMove = list;
			}
		}
		if (bestScore > 0) {
			return nextMove;
		} else {
			return null;
		}
	}
}
