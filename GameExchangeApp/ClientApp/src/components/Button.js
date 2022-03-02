import React from 'react'

const Button = ({ showGames, onClick}) => {
    return (
        <button className='btn' style={showGames ? { backgroundColor: 'red' } : {backgroundColor : 'green'}} onClick={onClick}>
            {showGames ? 'Hide my games' : 'Show my games'}
        </button>
    )
}

export default Button
