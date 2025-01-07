import { StatusBar } from 'expo-status-bar';
import { Button, KeyboardAvoidingView, StyleSheet, Text, TextInput, View } from 'react-native';

export default function App() {
  return (
    <View style={styles.container}>
      <KeyboardAvoidingView>
      <View style={{ borderBottomWidth:1}}>
       <Text style={{fontSize:20,fontWeight:1}}>Đăng nhập </Text>
       </View>
      <View style={styles.view1}> 
        <Text style={{fontSize:20 , margin:20}}>Nhập số điện thoại 

        </Text>
        <Text style={{margin:20,}}>Dùng số điện thoại để đăng nhập hoặc đăng ký tài khoản tại OneHousing Pro</Text>
        <TextInput style={{borderBottomWidth:1,margin:20,top:20}} placeholder='Nhập số điện thoại của bạn' keyboardType='numeric' ></TextInput>
       <View style={{top:30 , fontSize:30,borderRadius:5}}>
        <Button  title='Tiếp tục'  keyboardType="numeric"  />
        <Text></Text>
        </View>
      </View>
      
      <StatusBar style="auto" />
      </KeyboardAvoidingView>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    top:50,
    margin:10,
   
  },
  view1:{
    top:100,
    fontSize:40,
  }
});
