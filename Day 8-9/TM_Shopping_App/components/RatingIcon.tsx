import { StyleSheet } from "react-native";
import Icon from "./Icon";

const RatingIcon = () => (
    <Icon source={require("../assets/icon_rating.png")} style={styles.icon} />
  );
  
  const styles = StyleSheet.create({
    icon: {
        width: 35,
        height: 35,
        tintColor: "orange",
        marginRight: 10,
    },
  });
  
  export default RatingIcon;
  