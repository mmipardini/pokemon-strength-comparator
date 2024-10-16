import React, { useState } from 'react';
import SelectComponent from './components/SelectComponent';
import { comparePokemon } from './services/api';

const App = () => {
  const [firstPokemon, setFirstPokemon] = useState("");
  const [secondPokemon, setSecondPokemon] = useState("");
  const [result, setResult] = useState("");

  const handleCompare = async () => {
    try {
      const comparisonResult = await comparePokemon(firstPokemon, secondPokemon);
      setResult(comparisonResult);
    } catch (error) {
      setResult("Error comparing Pokemon.");
    }
  };

  const pokemonOptions = ["pikachu", "charizard", "bulbasaur", "squirtle"];

  return (
    <div className="container">
      <h1 className="mt-5">Compare Pokemon Strength</h1>
      <SelectComponent
        label="Select first Pokemon"
        options={pokemonOptions}
        onChange={(e) => setFirstPokemon(e.target.value)}
      />
      <SelectComponent
        label="Select second Pokemon"
        options={pokemonOptions}
        onChange={(e) => setSecondPokemon(e.target.value)}
      />
      <button
        className="btn btn-primary"
        onClick={handleCompare}
        disabled={!firstPokemon || !secondPokemon}
      >
        Compare
      </button>
      {result && (
        <div className="mt-3">
          <h4>Result: {result}</h4>
        </div>
      )}
    </div>
  );
};

export default App;
