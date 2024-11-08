export default function (log) {
    if (typeof (log) === 'string') {
        return (<>{console.error(log)}</>)
    }
}