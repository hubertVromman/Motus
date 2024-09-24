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
            Letter[] toReturn = new Letter[toFind.Length];
            for (int i = 0; i < toFind.Length; i++) {
                toReturn[i] = new Letter() {
                    letter = toFind[i],
                    notPresent = true,
                };
            }
            for (int i = 0; i < toFind.Length; i++) {
                if (toFind[i] == userGuess[i]) {
                    toReturn[i] = new Letter(i) {
                        letter = toFind[i],
                        isWellPlaced = true,
                    };
                }
            }
            for (int i = 0; i < toFind.Length; i++) {
                for (int j = 0; j < toFind.Length; j++) {
                    if (toFind[i] == userGuess[i] && i != j) {
                        toReturn[i] = new Letter(i) {
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
