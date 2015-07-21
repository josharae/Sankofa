using UnityEngine;
using System.Collections.Generic;

public class Oware_Script_DeathAI : MonoBehaviour {

	Oware_Script_Game osg;

	// Use this for initialization
	void Start () {
		osg = GetComponent<Oware_Script_Game> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public string Move(){
		int theIndex;
		theIndex = FindBestOffensiveMove();
		if (theIndex != -1){
			List<List<Transform>> nextBoard = GetPossibleBoard(osg.groups[theIndex]);
			int deathScore = FindBestScore();
			int playerScore = GetPossibleLoss(nextBoard);
			if (deathScore < playerScore){
				theIndex = FindBestDefensiveMove();
			}
		}
		else{
			theIndex = GetDangerMarbles();
			if (theIndex == -1){
				theIndex = SetupPlayerMarblesForScore();
				if (theIndex == -1){
					theIndex = GetLeastHarmfulMove();
				}
			}
		}
		string slot = "";
		if (theIndex == 6){
			slot = "7";
		}
		else if (theIndex == 7){
			slot = "8";
		}
		else if (theIndex == 8){
			slot = "9";
		}
		else if (theIndex == 9){
			slot = "10";
		}
		else if (theIndex == 10){
			slot = "11";
		}
		else if (theIndex == 11){
			slot = "12";
		}
		return slot;
	}

	private List<List<Transform>> GetPossibleBoard(List<Transform> nextMove){
		int size = nextMove.Count;
		List<List<Transform>> newBoard = new List<List<Transform>> ();
		for (int a = 0; a < 12; a++) {
			Transform[] temp1 = new Transform[osg.groups[a].Count];
			osg.groups[a].CopyTo(temp1);
			List<Transform> temp2 = new List<Transform>();
			temp2.AddRange(temp1);
			newBoard.Add(temp2);
		}
		int index = GetIndexOf (newBoard, nextMove);
		int nextMoveIndex = 0;
		for (int i = index; i < size + index; i++) {
			int j = i;
			while (j >= 11)
				j -= 12;
			newBoard[j+1].Add(nextMove[nextMoveIndex]);
			nextMoveIndex++;
		}
		newBoard [index].Clear ();
		return newBoard;
	}

	private int GetPossibleScore(List<List<Transform>> possibleBoard, List<Transform> nextMove){
		int size = nextMove.Count;
		int index = GetIndexOf (possibleBoard, nextMove);
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

	private int FindBestOffensiveMove(){
		int moveIndex = -1;
		int bestScore = 0;
		for (int i = 6; i < 12; i++) {
			List<Transform> list = new List<Transform> ();
			Transform[] temp = new Transform[osg.groups[i].Count];
			osg.groups[i].CopyTo(temp);
			list.AddRange(temp);
//			osg.groups[i].CopyTo(list);
			List<List<Transform>> possibleBoard = GetPossibleBoard(list);
			int possibleScore = GetPossibleScore(possibleBoard, list);
			if (possibleScore > bestScore){
				bestScore = possibleScore;
				moveIndex = i;
			}
		}
		return moveIndex;
	}

	private int FindBestDefensiveMove(){
		int nextIndex = -1;
		int bestDefense = 0;
		for (int i = 6; i < 12; i++) {
			List<Transform> list = new List<Transform> ();
			Transform[] temp = new Transform[osg.groups[i].Count];
			osg.groups[i].CopyTo(temp);
			list.AddRange(temp);
			List<List<Transform>> possibleBoard = GetPossibleBoard(list);
			int possibleScore = GetPossibleLoss(possibleBoard);
			if (possibleScore > bestDefense){
				bestDefense = possibleScore;
				List<Transform> playerMove = GetBestPlayerMove(possibleBoard);
				List<List<Transform>> newBoard = GetPossibleBoard(playerMove);
				int index = playerMove.Count + GetIndexOf(newBoard, playerMove);
				while (index >= 12){
					index -= 12;
				}
				nextIndex = index;
			}
		}
		return nextIndex;
	}

	private int GetDangerMarbles(){
		List<List<Transform>> board = new List<List<Transform>> ();
		for (int a = 0; a < 12; a++) {
			Transform[] temp1 = new Transform[osg.groups[a].Count];
			osg.groups[a].CopyTo(temp1);
			List<Transform> temp2 = new List<Transform>();
			temp2.AddRange(temp1);
			board.Add(temp2);
		}
		List<List<Transform>> danger = new List<List<Transform>> ();
		for (int i = 6; i < 12; i++) {
			List<Transform> list = board[i];
			List<Transform> list2 = osg.b1children;
			if (list.Count == 1 || list.Count == 2){
				danger.Add(list);
			}
		}
		if (danger.Count > 0) {
			int index = Random.Range (0, danger.Count);
			return index;
		} else {
			return -1;
		}
	}

	private int SetupPlayerMarblesForScore(){
		List<List<Transform>> board = new List<List<Transform>> ();
		int nextIndex = -1;
		for (int a = 0; a < 12; a++) {
			Transform[] temp1 = new Transform[osg.groups[a].Count];
			osg.groups[a].CopyTo(temp1);
			List<Transform> temp2 = new List<Transform>();
			temp2.AddRange(temp1);
			board.Add(temp2);
		}
		int bestScore = 0;
		for (int i = 6; i < 12; i++) {
			List<Transform> list = board[i];
			List<List<Transform>> newBoard = GetPossibleBoard(list);
			int size = list.Count;
			int index = GetIndexOf(board, list) + size;
			while (index >= 12){
				index -= 12;
			}
			List<Transform> playerList = newBoard[index];
			int marbles = 0;
			int count = 0;
			while (playerList.Count == 0 || playerList.Count == 1 && index < 6){
				marbles = marbles + playerList.Count + 1;
				count++;
				index++;
				if (index < 6)
					playerList = newBoard[index];
			}
			int score = marbles + count;
			if (bestScore < score){
				bestScore = score;
				nextIndex = i;
			}
		}
		return nextIndex;
	}

	private int FindBestScore(){
		int bestScore = 0;
		for (int i = 6; i < 12; i++) {
			List<Transform> list = new List<Transform> ();
			Transform[] temp = new Transform[osg.groups[i].Count];
			osg.groups[i].CopyTo(temp);
			list.AddRange(temp);
			List<List<Transform>> possibleBoard = GetPossibleBoard(list);
			int possibleScore = GetPossibleScore(possibleBoard, list);
			if (possibleScore > bestScore){
				bestScore = possibleScore;
			}
		}
		return bestScore;
	}

	private int GetPossibleLoss(List<List<Transform>> firstBoard){
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

	private List<Transform> GetBestPlayerMove(List<List<Transform>> firstBoard){
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

	private int GetLeastHarmfulMove(){
		List<List<Transform>> board = new List<List<Transform>> ();
		for (int a = 0; a < 12; a++) {
			Transform[] temp1 = new Transform[osg.groups[a].Count];
			osg.groups[a].CopyTo(temp1);
			List<Transform> temp2 = new List<Transform>();
			temp2.AddRange(temp1);
			board.Add(temp2);
		}
		int bestCount = 100000;
		for (int i = 6; i < 12; i++) {
			List<Transform> list = board[i];
			List<List<Transform>> newBoard = GetPossibleBoard(list);
			int count = 0;
			for (int j = 6; j < 12; j++){
				List<Transform> newList = newBoard[j];
				int size = newList.Count;
				if (size == 1 || size == 2){
					count += size;
				}
			}
			if (count < bestCount){
				bestCount = count;
			}
		}
		List<List<Transform>> lhMoves = new List<List<Transform>> ();
		for (int k = 6; k < 12; k++) {
			List<Transform> temp = board[k];
			List<List<Transform>> tempBoard = GetPossibleBoard(temp);
			int count = 0;
			for (int l = 6; l < 12; l++){
				List<Transform> check = tempBoard[l];
				int size = check.Count;
				if (size == 1 || size == 2){
					count += size;
				}
			}
			if (count == bestCount){
				lhMoves.Add(temp);
			}
		}
		List<Transform> nextMove = null;
		int listSize = lhMoves.Count;
		int finalIndex;
		if (listSize > 1) {
			finalIndex = Random.Range (0, listSize) + 6;
		} else {
			finalIndex = 0;
		}
		return finalIndex;
	}

	private int GetIndexOf(List<List<Transform>> board, List<Transform> move){
		int index = -1;
		for (int i = 0; i < board.Count; i++) {
			List<Transform> list = board[i];
			int count = 0;
			for (int j = 0; j < list.Count; j++){
				if (j < move.Count){
					if (list[j] == move[j]){
						count++;
					}
				}
			}
			if (count == list.Count && count == move.Count){
				index = i;
			}
		}
		return index;
	}
}