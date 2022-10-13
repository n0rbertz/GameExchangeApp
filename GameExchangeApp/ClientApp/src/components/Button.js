import React from 'react'

const Button = ({ title, onClick, color}) => {
    return (
        <button className='btn' style={ color } onClick={onClick}>
            {title}
        </button>
    )
}

export default Button
