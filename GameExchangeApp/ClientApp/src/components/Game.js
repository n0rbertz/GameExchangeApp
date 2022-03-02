import React from 'react'
import Card from 'react-bootstrap/Card'

const Game = ({ title, release, genre }) => {
    return (
        <div className='gamecard'>
            <Card style={{ width: '18rem' }}>
                <Card.Body>
                    <Card.Title>{ title }</Card.Title>
                    <Card.Subtitle className="mb-2 text-muted">{ release }</Card.Subtitle>
                    <Card.Text>
                        { genre }
                    </Card.Text>
                </Card.Body>
            </Card>
        </div>
    )
}

export default Game
