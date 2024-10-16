import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { comparePokemon } from './services/api';

const App = () => {
  const [firstPokemon, setFirstPokemon] = useState('');
  const [secondPokemon, setSecondPokemon] = useState('');
  const [result, setResult] = useState('');
  const [pokemons, setPokemons] = useState([]);
  const apiUrl = 'https://pokeapi.co/api/v2/pokemon';
  const defaultImageUrl = 'https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/Pokemon_Trading_Card_Game_cardback.jpg/220px-Pokemon_Trading_Card_Game_cardback.jpg';

  useEffect(() => {
    const fetchPokemons = async () => {
      const response = await fetch(apiUrl);
      const data = await response.json();
      setPokemons(data.results);
    };
    fetchPokemons();
  }, []);

  const handleCompare = async () => {
    try {
      const comparisonResult = await comparePokemon(firstPokemon, secondPokemon);
      setResult(comparisonResult);
    } catch (error) {
      setResult("Error comparing Pokemon.");
    }
  };

  return (
    <div className="container mt-5">
      <h1 className="text-center mb-4">Pokemon Strength Comparator</h1>
      <div className="row mb-4">
        <div className="col-md-6">
          <select
            className="form-select"
            onChange={(e) => setFirstPokemon(e.target.value)}
          >
            <option value="">Select first Pokemon</option>
            {pokemons.map((pokemon) => (
              <option key={pokemon.name} value={pokemon.name}>
                {pokemon.name}
              </option>
            ))}
          </select>
        </div>
        <div className="col-md-6">
          <select
            className="form-select"
            onChange={(e) => setSecondPokemon(e.target.value)}
          >
            <option value="">Select second Pokemon</option>
            {pokemons.map((pokemon) => (
              <option key={pokemon.name} value={pokemon.name}>
                {pokemon.name}
              </option>
            ))}
          </select>
        </div>
      </div>
      <button className="btn btn-primary mb-4" onClick={handleCompare}>
        Compare
      </button>

      <div className="row">
        <div className="col-md-12">
          {result && (
            <div className="alert alert-info text-center" role="alert">
              {result}
            </div>
          )}
        </div>
      </div>

      <div className="row">
        <div className="col-md-6">
          <h2 className="text-center">Selected Pokemon</h2>
          <div className="card mb-4 pokemon-card">
            <img
              src={firstPokemon ? `https://img.pokemondb.net/sprites/home/normal/${firstPokemon}.png` : defaultImageUrl}
              alt={firstPokemon}
              className="card-img-top"
            />
            <div className="card-body">
              <h5 className="card-title">{firstPokemon}</h5>
            </div>
          </div>
        </div>
        <div className="col-md-6">
          <h2 className="text-center">Selected Pokemon</h2>
          <div className="card mb-4 pokemon-card">
            <img
              src={secondPokemon ? `https://img.pokemondb.net/sprites/home/normal/${secondPokemon}.png` : defaultImageUrl}
              alt={secondPokemon}
              className="card-img-top"
            />
            <div className="card-body">
              <h5 className="card-title">{secondPokemon}</h5>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default App;
