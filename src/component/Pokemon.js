import React from "react";
import { useState, useEffect } from "react";
import loadingImg from '../images/loading.png'


function Pokemon() {
    //useState
    const [pokeId, setPokeId] = useState(1);
    const [pokemon, setPokemon] = useState({ name: '', weight: '', imgFront: '', imgBack: '' })
    const [loading, setLoading] = useState(false);

    //useEffect
    useEffect(() => {
        //check pokeId is truthy value: not false, 0, emptyString, null, undefined, NaN
        if (pokeId) {
            //start loading data -> render Loading...
            setLoading(true)
            //fetch to get name and weight
            fetch(`https://pokeapi.co/api/v2/pokemon/${pokeId}`)
                .then(response => response.json())
                .then(pokemon => {
                    //check array forms undefined or empty
                    if (pokemon.forms && pokemon.forms.length > 0) {
                        //set name & weight
                        setPokemon({
                            name: pokemon.forms[0].name,
                            weight: pokemon.weight,
                            imgBack: pokemon.sprites.back_default,
                            imgFront: pokemon.sprites.front_default
                        })
                    }
                })
                .catch(function (error) {
                })
                .finally(() => {
                    //Data load done
                    setLoading(false)
                })

        }
    }, [pokeId])

    return (
        <div>
            {/* Loading text */}
            {loading && <p style={{ color: 'red', fontWeight: 'bold' }} >Loading...</p>}
            {/* Loading image */}
            {loading && <img src={loadingImg} width="50px" />}
            <p>ID: {pokeId}</p>
            <p>Name: {pokemon.name}</p>
            <p>Weight: {pokemon.weight}</p>
            <img src={pokemon.imgBack} width='100px' />
            <img src={pokemon.imgFront} width='100px' />
            <br />
            <button
                //if id = 1, no more `Back`
                onClick={() => setPokeId(prev => (prev > 1 ? prev - 1 : 1))}
                disabled={pokeId === 1}
                style={{ margin: '0px 30px' }}
            >
                Back
            </button>
            <button
                onClick={() => setPokeId(pokeId + 1)}
            >
                Next
            </button>
        </div>
    )
}

export default Pokemon