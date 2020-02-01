﻿using System.Collections.Generic;
using UnityEngine;

/** All possible food containers in the game */
public enum FoodContainerType
{
	Taco,
	Bowl
}

/** Attached to a food container in game so it can track what ingredients it currently holds */
public class FoodContainer : MonoBehaviour
{
	[Tooltip("List of 'sockets' for attaching an ingredient model to the container. Starts at front of list and continues (socket at index 0 used first)")]
	public List<Transform> Sockets;

	/// <summary>
	/// All ingredients currently attached to this container
	/// </summary>
	private List<Ingredient> Ingredients;

	/** Add a ingredient mesh to this container */
	public bool AddIngredient(Ingredient inIngredient)
	{
		//Get the container manager
		ContainerManager containerManager = ContainerManager.SharedInstance;

		//Get the manager's ingredient container
		IngredientMeshContainer ingredientContainer = containerManager.IngredientMeshContainer;

		//get free socket index in sockets list
		Transform socket;

		int freeSocket = GetFreeSocket(out socket);

		//no free sockets, do not continue
		if(freeSocket == -1)
		{
			return false;
		}

		//Poll ingredient container for the material to add at this layer
		GameObject ingredientMesh = ingredientContainer.GetIngredientForLayer(inIngredient.IngredientType, freeSocket);

		//if mesh not found, do not continue
		if(ingredientMesh == null)
		{
			return false;
		}

		//attach the ingredient model to the socket
		ingredientMesh.transform.SetParent(socket);
		ingredientMesh.transform.localPosition = Vector3.zero;

		Ingredients.Add(inIngredient);

		return true;
	}

	/** Return first available socket (no kids) */
	private int GetFreeSocket(out Transform outSocket)
	{
		for(int i = 0; i < Sockets.Count; i++)
		{
			Transform socket = Sockets[i];
			if(socket.childCount == 0)
			{
				outSocket = socket;
				return i;
			}
		}

		outSocket = null;
		return -1;
	}
}