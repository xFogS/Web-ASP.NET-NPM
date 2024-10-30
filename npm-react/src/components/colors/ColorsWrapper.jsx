//fetch, useState, useEffect
import { useState, useEffect } from 'react'
import ColorItem from "./ColorsItem"
export default function ColorsWrapper() {
    const [colors, setColors] = useState([]);
    const [paginate, setPaginate] = useState();

    const getColors = () =>
    {
        fetch(`http://localhost:80/api/ApiColor`)
            .then(req => { if (req.ok) return req.json(); })
            .then(req => {
                setColors(req.data);
                setPaginate(req.paginate);
                console.log(req)
            })
            .catch(err => { console.error(err) })
    }

    useEffect(() => { getColors() }, []);

    return (
        <>
            <h1> Colors </h1>
            <ul>
                {colors.map((color, i) => (
                    <ColorItem color={color} key={i} />
                ))}
            </ul>
        </>
    )

}
