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
        FormulaDictionary.Add(new Formula(1, 2), 12);
        FormulaDictionary.Add(new Formula(3, 4), 5);
        FormulaDictionary.Add(new Formula(2, 5), 6);
        FormulaDictionary.Add(new Formula(2, 6), 7);
        FormulaDictionary.Add(new Formula(5, 6), 8);
        FormulaDictionary.Add(new Formula(1, 8), 9);
        FormulaDictionary.Add(new Formula(2, 9), 10);
        FormulaDictionary.Add(new Formula(1, 10), 11);
        FormulaDictionary.Add(new Formula(11, 7), 14);
        FormulaDictionary.Add(new Formula(14, 4), 15);
        FormulaDictionary.Add(new Formula(11, 15), 16);
        FormulaDictionary.Add(new Formula(12, 16), 17);
        FormulaDictionary.Add(new Formula(1, 7), 13);
    }

}