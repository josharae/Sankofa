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
			PlayerMarbles.Add(osg.groups[j]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!osg.isPlayerTurn) {
			if (!osg.isMoving && !osg.isCollecting){
				List<Transform> nextMove = FindBestOffensiveMove();
				List<List<Transform>> nextBoard = GetPossibleBoard(nextMove);
				int deathScore = FindBestScore();
				int playerScore = GetPossibleLoss(nextBoard);
				if (deathScore < playerScore){
					nextMove = FindBestDefensiveMove();
				}
				else if (deathScore == playerScore && deathScore == 0){
				}
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

	public List<List<Transform>> GetPossibleBoard(List<Transform> nextMove){
		int size = nextMove.Count;
		int index = osg.groups.IndexOf (nextMove);
		List<List<Transform>> newBoard = osg.groups;
		for (int i = index; i < size + index; i++) {
			int j = i;
			while (j >= 11)
				j -= 12;
			newBoard[j+1].Add(nextMove[i]);
		}
		newBoard [index].Clear ();
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

	public List<Transform> FindBestOffensiveMove(){
		List<Transform> nextMove = null;
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
		return nextMove;
	}

	public List<Transform> FindBestDefensiveMove(){
		List<Transform> nextMove = null;
		int bestDefense = 0;
		for (int i = 6; i < 12; i++) {
			List<Transform> list = osg.groups[i];
			List<List<Transform>> possibleBoard = GetPossibleBoard(list);
			int possibleScore = GetPossibleLoss(possibleBoard);
			if (possibleScore > bestDefense){
				bestDefense = possibleScore;
				List<Transform> playerMove = GetBestPlayerMove(possibleBoard);
				List<List<Transform>> newBoard = GetPossibleBoard(playerMove);
				int index = playerMove.Count + newBoard.IndexOf(playerMove);
				while (index >= 12){
					index -= 12;
				}
				nextMove = newBoard[index];
			}
		}
		return nextMove;
	}

	public int FindBestScore(){
		int bestScore = 0;
		for (int i = 6; i < 12; i++) {
			List<Transform> list = osg.groups[i];
			List<List<Transform>> possibleBoard = GetPossibleBoard(list);
			int possibleScore = GetPossibleScore(possibleBoard, list);
			if (possibleScore > bestScore){
				bestScore = possibleScore;
			}
		}
		return bestScore;
	}

	public int GetPossibleLoss(List<List<Transform>> firstBoard){
		int bestPlayerScore = 0;
		for (int i = 0; i < 6; i++){
			List<Transform> playerMove = firstBoard[i];
			List<List<Transform>> secondBoard = GetPossibleBoard(playerMove);
			int playerPoints = GetPossibleScore(secondBoard, playerMove);
			if (bestPlayerScore < playerPoints){
				bestPlayerScore = playerPoints;
			}
		}
		return bestPlayerScore;
	}

	public List<Transform> GetBestPlayerMove(List<List<Transform>> firstBoard){
		int bestPlayerScore = 0;
		List<Transform> bestPlayerMove = null;
		for (int i = 0; i < 6; i++){
			List<Transform> playerMove = firstBoard[i];
			List<List<Transform>> secondBoard = GetPossibleBoard(playerMove);
			int playerPoints = GetPossibleScore(secondBoard, playerMove);
			if (bestPlayerScore < playerPoints){
				bestPlayerScore = playerPoints;
				bestPlayerMove = playerMove;
			}
		}
		return bestPlayerMove;
	}
}
