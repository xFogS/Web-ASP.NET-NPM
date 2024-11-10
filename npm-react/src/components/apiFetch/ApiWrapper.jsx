import { useEffect, useState } from "react";
import apiFetch from "./colors/ColorApiFetch.jsx";

export default function () {


    const [colors, setColors] = useState([]);
    const [pageNumber, setpageNumber] = useState(1);
    const [pageSize, setPageSize] = useState(10);


    const getData = () => {

        const searchParams = [
            { name: 'pageNumber', value: pageNumber },
            { name: 'pageSize', value: pageSize },
        ]

        apiFetch(searchParams)
            .then(data => {
                setColors(data)
            })
    }

    const doSetSize = (ev) => {
        const v = ev.target.value
        if (v < 1 || v > 20) { return }
        setPageSize(ev.target.value)
    }

    const doSetPage = (ev) => {
        const v = ev.target.value
        if (v < 1 || v > 20) { return }
        setpageNumber(ev.target.value)
    }

    useEffect(() => {
        getData()
    }, [pageSize, pageNumber]);


    return (<>
        <h1> Data from MockApi</h1>
        <div>
            <label>Limit: <input type='number'
                value={pageSize}
                onChange={doSetSize} /></label>

            <label>Page: <input type='number'
                value={pageNumber}
                onChange={doSetPage} /></label>
        </div>
        <ul>
            {products.map((p, i) =>
            (<li key={i}>
                <p>{p.name}</p>
                <img src={p.url} width='50px' />\
                <p>{p.rgb}</p>
                <p>{p.color}</p>
            </li>))}
        </ul>
    </>)
}