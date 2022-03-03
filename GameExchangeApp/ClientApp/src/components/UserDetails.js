import React from 'react'
import UserDetail from './UserDetail'
import Button from './Button'
import Game from './Game'
import { useState, useEffect } from 'react'

const UserDetails = () => {
    const [showGames, setShowGames] = useState(false)


    const user =
    {
        Name: 'John Doe',
        Location: 'Kansas',
    }
    const [gamesOwned, setGamesOwned] = useState([])

    useEffect(() => {
        const getGames = async () => {
            const games = await fetchGames()
            setGamesOwned(games)
        }
        getGames()
        console.log(gamesOwned)
    }, [])

    const fetchGames = async () => {
        const res = await fetch('https://localhost:5001/api/gamers/1/gamesowned')
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
            {Object.entries(user).map(([key, value]) => {
                return (<UserDetail detailType={key} detail={value} />)
            })}
            </div>
            <div className='games'>
                <Button showGames={ showGames } onClick={onClickGamesButton } />
                {showGames ? gamesOwned.map((game) => (<Game title={game.title} release={game.releaseDate} genre={ game.genre} />)) : ''}
            </div>
        </div>
    )
}

export default UserDetails
