import { useState } from "react";
import { Text, TouchableOpacity, View } from "react-native";

type CounterItemProps =
{
    counter : number,
    setCounter : React.Dispatch<React.SetStateAction<number>>
}


const CounterItem = ({counter,setCounter}:CounterItemProps) =>{
    const [counter2,setCounter2] = useState(1)
    return(
<View style={{flexDirection: "row",width:80, justifyContent: "space-around" ,backgroundColor: "lightgray", borderRadius: 100}}>
<TouchableOpacity onPress={() =>{
    if(counter-1 > 0)setCounter(counter-1)}}>
    <Text style={{fontSize: 25 , fontWeight: "bold"}}>-</Text>
</TouchableOpacity>
<Text style={{fontSize: 25 }}>{counter}</Text>
<TouchableOpacity onPress={() =>setCounter(counter+1)}>
    <Text style={{fontSize: 25 , fontWeight: "bold"}}>+</Text>
</TouchableOpacity>
</View>)};

export default CounterItem;