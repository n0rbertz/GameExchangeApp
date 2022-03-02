import React from 'react'
import UserDetail from './UserDetail'
import Button from './Button'
import Game from './Game'
import { useState } from 'react'

const UserDetails = () => {
    const [showGames, setShowGames] = useState(false)


    const user =
    {
        Name: 'John Doe',
        Location: 'Kansas',
    }
    const gamesOwned = [
        {
            Title: 'Devil May Cry',
            Release: 2003,
            Genre: 'Hack and slash'
        }
    ]

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
                {showGames ? gamesOwned.map((game) => (<Game title={game.Title} release={game.Release} genre={ game.Genre} />)) : ''}
            </div>
        </div>
    )
}

export default UserDetails
