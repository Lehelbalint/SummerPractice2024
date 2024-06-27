export const COLORS = {
  primary: "#010409",
  secondary: "#161B22",
  accent: "#1A73E8",
  success: "#00C851",
  error: "#ff4444",
  black: "#171717",
  white: "#FFFFFF",
  background: "#252C4A",
  grayPrimary: "#282E35",
  graySecondary: "#8C8C8C",
  grayLight: "#EEEEEE",
};

export const FONTS = {
  title: {
    marginTop: 30,
    marginBottom: 30,
    fontSize: 26,
    fontFamily: "Raleway-Bold",
    textAlign: "center",
    color: "white",
  },
};

export const STYLES = {
  textPrimary: {
    fontSize: 18,
    fontWeight: "800" as FontWeight,
    textTransform: "capitalize" as textTransform,
    color: COLORS.black,
  },
  textSecondary: {
    color: COLORS.graySecondary,
    fontSize: 14,
    textTransform: "capitalize" as textTransform,
  },
  mainScreen: { flex: 1, backgroundColor: "white" },
};

type FontWeight =
  | "normal"
  | "bold"
  | "100"
  | "200"
  | "300"
  | "400"
  | "500"
  | "600"
  | "700"
  | "800"
  | "900";

type textTransform =
  | "capitalize"
  | "none"
  | "uppercase"
  | "lowercase"
  | undefined;
