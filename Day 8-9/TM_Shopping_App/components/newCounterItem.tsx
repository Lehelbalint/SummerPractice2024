import { useState } from "react";
import { Text, TouchableOpacity, View } from "react-native";


interface NewCounterItemProps {
    initialCounter: number;
    setCounter: React.Dispatch<React.SetStateAction<number>>;
  }
  
  const NewCounterItem: React.FC<NewCounterItemProps> = ({ initialCounter, setCounter }) => {
    const [counter, localSetCounter] = useState(initialCounter);
  
    const updateCounter = (value: number) => {
      localSetCounter(value);
      setCounter(value);
    };
  
    return (
      <View style={{ flexDirection: "row", width: 80, justifyContent: "space-around", marginTop: 60,backgroundColor: "lightgray",position:"absolute", borderRadius: 100 }}>
        <TouchableOpacity onPress={() => {
          if (counter - 1 > 0) updateCounter(counter - 1);
        }}>
          <Text style={{ fontSize: 25, fontWeight: "bold" }}>-</Text>
        </TouchableOpacity>
        <Text style={{ fontSize: 25 }}>{counter}</Text>
        <TouchableOpacity onPress={() => updateCounter(counter + 1)}>
          <Text style={{ fontSize: 25, fontWeight: "bold" }}>+</Text>
        </TouchableOpacity>
      </View>
    );
  };
  
  
  export default NewCounterItem;