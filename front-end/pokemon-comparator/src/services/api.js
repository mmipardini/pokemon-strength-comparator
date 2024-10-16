export const comparePokemon = async (firstPokemon, secondPokemon) => {
    const apiUrl = 'https://localhost:7205';
    
    try {
        const response = await fetch(`${apiUrl}/api/Pokemon/strongest?firstPokemon=${firstPokemon}&secondPokemon=${secondPokemon}`);
    
        if (!response.ok) {
            console.error("Error:", response.status, response.statusText);
            return;
        }
        const resultString = await response.text(); 
        return resultString;
    
    } catch (error) {
        console.error("Fetch error:", error);
    }
  };
