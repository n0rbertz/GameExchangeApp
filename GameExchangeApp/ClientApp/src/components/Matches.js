import React from 'react'
import UserCard from './UserCard'
import {useState, useEffect} from 'react'

const Matches = () => {
    const [matchedGamers, setMatchedGamers] = useState([])

    useEffect(() => {
        const getMatches = async () => {
            const matches = await fetchMatches()
            setMatchedGamers(matches)
        }
        getMatches()
        console.log(matchedGamers)
    }, [])

    const fetchMatches = async () => {
        const res = await fetch('https://localhost:5001/api/gamers/31870695-e79d-4fe3-b139-14a141625175/matches')
        const data = await res.json()
        return data
    }

    return (
        <div>
            <div className="header">
                <h1>Matches</h1>
            </div>
            <div>
                {matchedGamers.map((gamer) => (<UserCard name={gamer.name} location={gamer.location} games={gamer.gamesOwned}/>))}
            </div>
        </div>

    )
}

export default Matches
