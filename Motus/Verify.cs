using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motus {
    public static class Verify {
        public static Letter[] verifyWord(string toFind, string userGuess) {
            toFind = toFind.ToLower();
            userGuess = userGuess.ToLower();

            //initialiser toReturn avec valeurs par defaut
            Letter[] toReturn = new Letter[toFind.Length];
            for (int i = 0; i < toFind.Length; i++) {
                toReturn[i] = new Letter() {
                    letter = userGuess[i],
                    notPresent = true,
                };
            }

            //check lettre bien placée
            for (int i = 0; i < toFind.Length; i++) {
                if (toFind[i] == userGuess[i]) {
                    toReturn[i] = new Letter(i) {
                        letter = toFind[i],
                        isWellPlaced = true,
                    };
                }
            }

            //check lettre mal placée
            for (int i = 0; i < toFind.Length; i++) {
                for (int j = 0; j < userGuess.Length; j++) {
                    if (toFind[i] == userGuess[j] && i != j) {
                        char lt = toFind[i];
                        int countInToFind = toFind.Count(l => l == lt);
                        foreach (Letter l in toReturn) {
                            if (l.letter == lt && l.isWellPlaced)
                                countInToFind--;
                        }
                        int countInUserGuess = 0;
                        for (int k = 0; k <= j; k++) {
                            if (userGuess[k] == lt && toFind[k] != lt)
                                countInUserGuess++;
                        }
                        if (countInUserGuess < countInToFind)
                            toReturn[i] = new Letter() {
                                letter = toFind[i],
                                isWrongPlaced = true,
                            };
                    }
                }
            }
            return toReturn;
        }
    }
}
