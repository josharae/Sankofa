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
			List<List<Transform>> nextBoard = GetPossibleBoard(osg.groups, osg.groups[theIndex]);
			int deathScore = GetPossibleScore(osg.groups, osg.groups[theIndex]);
			int playerScore = GetPossibleLoss(nextBoard);
			if (deathScore < playerScore){
				theIndex = FindBestDefensiveMove();
			}
		}
		else{
			int playerScore = GetPossibleLoss(osg.groups);
			int possibleIndex = FindBestDefensiveMove();
			if (playerScore > 0 && possibleIndex != -1){
				theIndex = FindBestDefensiveMove();
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
		}
		string slot = "";
		if (theIndex == 6) {
			slot = "7";
		} else if (theIndex == 7) {
			slot = "8";
		} else if (theIndex == 8) {
			slot = "9";
		} else if (theIndex == 9) {
			slot = "10";
		} else if (theIndex == 10) {
			slot = "11";
		} else if (theIndex == 11) {
			slot = "12";
		} else {
			theIndex = GetLeastHarmfulMove();
			if (theIndex == 6) {
				slot = "7";
			} else if (theIndex == 7) {
				slot = "8";
			} else if (theIndex == 8) {
				slot = "9";
			} else if (theIndex == 9) {
				slot = "10";
			} else if (theIndex == 10) {
				slot = "11";
			} else if (theIndex == 11) {
				slot = "12";
			}
		}
		return slot;
	}

	private List<List<Transform>> GetPossibleBoard(List<List<Transform>> theBoard, List<Transform> nextMove){
		int size = nextMove.Count;
		List<List<Transform>> newBoard = new List<List<Transform>> ();
		for (int a = 0; a < 12; a++) {
			Transform[] temp1 = new Transform[theBoard[a].Count];
			theBoard[a].CopyTo(temp1);
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
		while (finalIndex >= 12) {
			finalIndex -= 12;
		}
		endPosition = possibleBoard[finalIndex];
		bool canCollect = true;
		while (finalIndex >= 0 && finalIndex < 6 && canCollect){
			if (endPosition.Count == 1) {
				possibleScore += 2;
			} else if (endPosition.Count == 2) {
				possibleScore += 3;
			} else {
				canCollect = false;
			}
			finalIndex--;
			if (finalIndex >= 0 && finalIndex < 6){
				endPosition = possibleBoard[finalIndex];
			}
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
			List<List<Transform>> possibleBoard = GetPossibleBoard(osg.groups, list);
			int possibleScore = GetPossibleScore(osg.groups, list);
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
			List<List<Transform>> possibleBoard = GetPossibleBoard(osg.groups, list);
			int possibleScore = GetPossibleLoss(possibleBoard);
			if (possibleScore > bestDefense){
				bestDefense = possibleScore;
				List<Transform> playerMove = GetBestPlayerMove(possibleBoard);
				List<List<Transform>> newBoard = GetPossibleBoard(possibleBoard, playerMove);
				int index = GetIndexOf(osg.groups, list);
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
			if (list.Count == 1 || list.Count == 2){
				danger.Add(list);
			}
		}
		if (danger.Count > 1) {
			int index1 = Random.Range (0, danger.Count);
			List<Transform> list2 = danger[index1];
			int index2 = GetIndexOf(osg.groups, list2);
			return index2;
		} else if (danger.Count > 0) {
			List<Transform> list2 = danger[0];
			int index = GetIndexOf(osg.groups, list2);
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
		List<int> slots = new List<int> ();
		for (int i = 6; i < 12; i++) {
			List<Transform> list = board[i];
			List<List<Transform>> newBoard = GetPossibleBoard(osg.groups, list);
			int size = list.Count;
			int index = GetIndexOf(board, list) + size;
			while (index >= 12){
				index -= 12;
			}
			List<Transform> playerList = newBoard[index];
			int marbles = 0;
			while (index >= 0 && index < 6){
				if (playerList.Count == 0 || playerList.Count == 1){
					marbles = marbles + playerList.Count + 1;
					if (index < 6)
						playerList = newBoard[index];
				}
				index--;
			}
			int score = marbles;
			if (bestScore <= score && score != 0){
				bestScore = score;
				slots.Add(i);
			}
		}
		if (slots.Count > 0) {
			int slotIndex = Random.Range(0, slots.Count);
			nextIndex = slots[slotIndex];
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
			List<List<Transform>> possibleBoard = GetPossibleBoard(osg.groups, list);
			int possibleScore = GetPossibleScore(osg.groups, list);
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
			List<List<Transform>> secondBoard = GetPossibleBoard(firstBoard, playerMove);
			int playerPoints = GetPossibleScore(firstBoard, playerMove);
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
			List<List<Transform>> secondBoard = GetPossibleBoard(firstBoard, playerMove);
			int playerPoints = GetPossibleScore(firstBoard, playerMove);
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
			List<List<Transform>> newBoard = GetPossibleBoard(osg.groups, list);
			int count = 0;
			if (list.Count > 0){
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
		}
		List<List<Transform>> lhMoves = new List<List<Transform>> ();
		for (int k = 6; k < 12; k++) {
			List<Transform> temp = board[k];
			List<List<Transform>> tempBoard = GetPossibleBoard(osg.groups, temp);
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
		} else if (listSize == 1) {
			finalIndex = 0;
		} else {
			finalIndex = -1;
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