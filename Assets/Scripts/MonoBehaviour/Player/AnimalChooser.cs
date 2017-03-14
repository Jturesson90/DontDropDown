﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalChooser : MonoBehaviour
{
    [HideInInspector]
    public Animal CurrentAnimal = null;

    public List<Animal> _animals;


    void Awake()
    {
        _animals = new List<Animal>();
        FillAnimalsList();
    }

    private void FillAnimalsList()
    {
        foreach (Transform child in transform)
        {
            var animalComponent = child.GetComponent<Animal>();
            if (animalComponent != null)
            {
                _animals.Add(animalComponent);
            }
        }
    }

    public void ChooseAnimal(int index)
    {
        foreach (Animal animal in _animals)
        {
            animal.gameObject.SetActive(false);
        }
        CurrentAnimal = _animals[index];
        CurrentAnimal.gameObject.SetActive(true);
    }
    public void ChooseRandomAnimal()
    {
        int randomIndex = Random.Range(0, _animals.Count);
        ChooseAnimal(randomIndex);
    }
}