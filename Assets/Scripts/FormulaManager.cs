using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormulaManager : MonoBehaviour
{
    public static FormulaManager Instance { get; private set; }

    public Dictionary<Formula, int> FormulaDictionary = new Dictionary<Formula, int>(); // formula to productID

    public class Formula
    {
        public int Ingredient1ID;
        public int Ingredient2ID;

        public Formula(int ingredient1ID, int ingredient2ID)
        {
            Ingredient1ID = ingredient1ID;
            Ingredient2ID = ingredient2ID;
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(Instance);
    }

    private void Start()
    {
        FormulaDictionary.Add(new Formula(1, 2), 4);
        FormulaDictionary.Add(new Formula(3, 6), 5);
    }

}