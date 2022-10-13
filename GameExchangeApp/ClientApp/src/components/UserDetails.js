import React from 'react'
import UserDetail from './UserDetail'
import Button from './Button'
import Game from './Game'
import { useState, useEffect } from 'react'

const UserDetails = () => {
    const [showGames, setShowGames] = useState(false)


    const [user, setUser] = useState({})
    const [gamesOwned, setGamesOwned] = useState([])

    useEffect(() => {
        const getUser = async () => {
            const user = await fetchUser()
            setUser(user)
        }
        const getGames = async () => {
            const games = await fetchGames()
            setGamesOwned(games)
        }
        getUser()
        getGames()
    }, [])

    const fetchGames = async () => {
        const res = await fetch('https://localhost:5001/api/user/a18d497c-76d1-4007-a8d3-5754c1c7bee9/gamesowned')
        const data = await res.json()
        return data
    }

    const fetchUser = async () => {
        const res = await fetch('https://localhost:5001/api/user/a18d497c-76d1-4007-a8d3-5754c1c7bee9')
        const data = await res.json()
        return data
    }

    const onClickGamesButton = () => {
        setShowGames(!showGames)
        gamesOwned.map((game) => (console.log(game)))
    }

    return (
        <div>
            <div className='userdetails'>
                <h3>Name: {user.userName}</h3>
                <h3>Location: { user.location}</h3>
            </div>
            <div className='games'>
                <Button title={showGames ? 'Hide my games' : 'Show my games'} color={showGames ? { backgroundColor: 'red' } : { backgroundColor: 'green' } } onClick={onClickGamesButton } />
                {showGames ? gamesOwned.map((game) => (<Game title={game.title} release={game.releaseDate} genre={ game.genre} />)) : ''}
            </div>
        </div>
    )
}

export default UserDetails
