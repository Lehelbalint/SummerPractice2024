# Types

export type Product = {
id: number;
brand: string;
category: string;
description: string;
discountPercentage: number;
quantity?: number;
images: string[];
rating: number;
thumbnail: string;
stock: string;
title: string;
price: number;
};

type Products = {
products: Product[];
};

# 1 BasketScreen Styles

const styles = StyleSheet.create({
//renderItem
productContainer: {
borderRadius: 20,
marginHorizontal: 20,
marginBottom: 20,
},
imageBackground: {
height: 100,
overflow: "hidden",
borderRadius: 10,
},
deleteIcon: { alignSelf: "flex-end", marginTop: 10, marginRight: 10 },
checkoutButton: { marginHorizontal: 20, marginVertical: 10 },
quantityButton: { marginBottom: 10, marginLeft: 10 },

textContainer: {
flexDirection: "row",
alignItems: "center",
},
textTitle: {
...STYLES.textPrimary,
marginTop: 5,
color: COLORS.black,
},
description: {
marginBottom: 10,
...STYLES.textSecondary,
},
price: {
fontSize: 20,
marginRight: 20,
fontWeight: "800",
color: COLORS.white,
},

//

safeArea: {
...STYLES.mainScreen,
},
emptySafeArea: {
alignItems: "center",
flex: 1,
justifyContent: "center",
},

title: {
...STYLES.textPrimary,
marginLeft: 20,
marginVertical: 10,
},

totalPricesFlex: { flexDirection: "row", marginVertical: 10 },

textTotal: {
marginHorizontal: 20,
fontSize: 16,
color: COLORS.graySecondary,
fontWeight: "600",
flex: 1,
},

textPrice: {
fontSize: 20,
fontWeight: "bold",
marginHorizontal: 20,
},
});

# 2 Checkout Screen Styles

const styles = StyleSheet.create({
//renderItem

productCard: {
height: 80,
marginVertical: 5,
flexDirection: "row",
paddingLeft: 10,
gap: 10,
alignItems: "center",
backgroundColor: COLORS.white,
borderRadius: 10,
width: "100%",
},

textTitle: {
...STYLES.textPrimary,
},
textDescription: {
...STYLES.textSecondary,
},

safeArea: {
...STYLES.mainScreen,
backgroundColor: COLORS.grayLight,
paddingHorizontal: 15,
},
title: {
...STYLES.textPrimary,
},
addressCard: {
marginVertical: 5,
paddingLeft: 10,
paddingVertical: 20,
gap: 10,
backgroundColor: COLORS.white,
borderRadius: 10,
width: "100%",
},

thumbnail: {
height: 50,
borderRadius: 10,
width: 50,
},

highlight: {
fontWeight: "bold",
},

orderButton: { borderRadius: 20, width: "50%", alignSelf: "center" },
});

# 3 Contact screen styles

const styles = StyleSheet.create({
safeArea: {
backgroundColor: COLORS.white,
flex: 1,
},
title: {
marginVertical: 10,
marginHorizontal: 20,
fontWeight: "bold",
fontSize: 22,
},
textInput: {
backgroundColor: COLORS.white,
marginHorizontal: 20,
marginVertical: 5,
paddingHorizontal: 10,
paddingVertical: 15,
borderRadius: 10,
borderWidth: 1,
borderColor: COLORS.grayLight,
},

image: {
width: "90%",
height: 180,
marginHorizontal: 20,
marginBottom: 10,
borderRadius: 10,
resizeMode: "contain",
},

buttonContainer: {
flexDirection: "row",
justifyContent: "space-between",
marginHorizontal: 20,
marginVertical: 20,
flex: 1,
alignItems: "flex-end",
},

cancelButton: {
width: 80,
backgroundColor: COLORS.white,
},

confirmButton: {
width: 100,
},
});

# 4 Product DetailsScreen Styles

const styles = StyleSheet.create({
safeArea: {
...STYLES.mainScreen,
},
backIcon: { marginLeft: 15, marginTop: 15 },


detailsCard: {
flex: 0.7,
backgroundColor: COLORS.white,
marginTop: -20,
borderTopEndRadius: 20,
borderTopLeftRadius: 20,
shadowOpacity: 0.25,
shadowRadius: 3.84,
elevation: 5,
paddingHorizontal: 20,
paddingVertical: 10,
},

ratingIcon: {
width: 35,
height: 35,
tintColor: "orange",
marginRight: 10,
},
reviewsWrapper: {
flexDirection: "row",
alignItems: "center",
marginVertical: 15,
},
stockText: {
fontWeight: "700",
marginTop: 22,
},

cartButton: { width: 150, borderRadius: 20, marginTop: 20 },
});

# 5 PRODUCT SCREEN STYLES

const styles = StyleSheet.create({
safeArea: {
...STYLES.mainScreen,
},
emptySafeArea: {
alignItems: "center",
flex: 1,
justifyContent: "center",
},
screenTitle: {
...STYLES.textPrimary,
marginBottom: 10,
},
container: {
width: "50%",
alignItems: "center",
shadowColor: "#000",
shadowOpacity: 0.15,
shadowRadius: 3.84,
elevation: 5,
},
image: {
width: 150,
height: 150,
borderRadius: 10,
},
textContainer: { marginHorizontal: 10, alignItems: "center" },
textTitle: {
...STYLES.textPrimary,
marginTop: 5,
},
textDescription: {
...STYLES.textSecondary,
textAlign: "justify",
},
textPrice: {
...STYLES.textPrimary,
marginBottom: 20,
},
indicator: {
alignSelf: "center",
},
});
