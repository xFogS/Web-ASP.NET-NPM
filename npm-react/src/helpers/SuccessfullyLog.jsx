export default function (log) {
    if (typeof (log) === 'string') {
        return (<>{console.log(log)}</>)
    }
}