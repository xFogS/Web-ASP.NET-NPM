export default function ColorItem(props) {
    return (
        <>
            <img
                src={`http://localhost:80${props.color.url}`}
                alt={`${props.color.name}`}
                width='25px'
                height="25px"
            />
        </>
    );
}