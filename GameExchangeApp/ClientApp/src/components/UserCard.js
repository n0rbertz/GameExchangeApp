import React from 'react'
import Game from './Game'
import Card from 'react-bootstrap/Card'

const User = ({ name, location, games }) => {
    return (
        <div className='gamecard'>
            <Card style={{ width: '18rem' }}>
                <Card.Body>
                    <Card.Title>{name}</Card.Title>
                    <Card.Subtitle className="mb-2 text-muted">{location}</Card.Subtitle>
                    {games.map((game) => (<Game title={game.title} release={game.releaseDate} genre={game.genre} />))}
                </Card.Body>
            </Card>
        </div>
    )
}

export default User
