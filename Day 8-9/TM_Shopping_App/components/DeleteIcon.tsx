import { StyleSheet } from "react-native";
import Icon from "./Icon";

const DeleteIcon = () => (
  <Icon source={require("../assets/icon_delete.png")} style={styles.icon} />
);

const styles = StyleSheet.create({
  icon: {
    width: 25,
    height: 25,
    backgroundColor: "black",
    tintColor: "white",
    margin: 2,
    borderRadius: 100
  },
});

export default DeleteIcon;