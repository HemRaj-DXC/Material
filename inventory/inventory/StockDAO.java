package com.dxc.inventory;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StockDAO {
	Connection connection;
	PreparedStatement pst;
	public String placeOrder( String stockId,  int qtyOrd) throws SQLException {
		Stock stock= searchStock(stockId);
		String result="";
		int price,billAmt;
		connection=ConnectionHelper.getConnection();
		
	
	int orderId = generateOrderId();
	int quantityAvail = stock.getQuantityAvail();
        	if ( quantityAvail !=0 ) {
        	String	cmd = "UPDATE STOCK SET QUANTITYAVAIL = QUANTITYAVAIL -? WHERE STOCKID =?";
        		pst = connection.prepareStatement(cmd);
    			pst.setInt(1, qtyOrd);
    			pst.setString(2, stockId);
    			pst.executeUpdate();
    			pst.close();
    	cmd = "select price from stock where stockid=?"		;
    	  pst=connection.prepareStatement(cmd);
    	  pst.setString(1,stockId);
    	  ResultSet rs=pst.executeQuery();
    	  rs.next();
    	  price = rs.getInt("price");
    	  billAmt =price*qtyOrd;
    	  pst.close();
    	  
    cmd="INSERT INTO ORDERS(ORDERID,STOCKID,QTYORD,BILLAMT)" + "values(?,?,?,?)";
    pst=connection.prepareStatement(cmd);		
   
	pst.setInt(1, orderId);
    pst.setString(2, stockId);
    pst.setInt(3,qtyOrd);
    pst.setInt(4,billAmt);
    pst.executeUpdate();
    pst.close();
   cmd="update amount set gamt=gamt+?";
   pst=connection.prepareStatement(cmd);
    pst.setInt(1,price*qtyOrd);
    pst.executeUpdate();
    			
     result= "order Created Successfully...";
        	}else{
        		result="STOCK NOT AVILABLE";
    			
        	}
    	
	
        	
        return result;
        	
        }
	   
	
			
	 
	

	
		
	
	
	
	
	
	


	public Stock searchStock(String stockId) throws SQLException {
		connection = ConnectionHelper.getConnection();
		String cmd = "select * from Stock Where StockId=?";
		Stock stock1 = null;
		pst = connection.prepareStatement(cmd);
		pst.setString(1, stockId);
		ResultSet rs = pst.executeQuery();
		if (rs.next()) {
			stock1 = new Stock();
			stock1.setStockId(rs.getString("stockid"));
			stock1.setPrice(rs.getInt("price"));
			stock1.setItemName(rs.getString("ItemName"));
			stock1.setQuantityAvail(rs.getInt("quantityAvail"));
			
		}
		return stock1;
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
//TO create Stock	
	public String createStock(Stock stock) throws SQLException {
		connection = ConnectionHelper.getConnection();
String cmd="Insert into STOCK(StockId,ItemName,Price,QuantityAvail)"+ "values(?,?,?,?)";
		pst=connection.prepareStatement(cmd);
		pst.setString(1, stock.getStockId());
		pst.setString(2, stock.getItemName());
		pst.setInt(3, stock.getPrice());
		pst.setInt(4, stock.getQuantityAvail());
		pst.executeUpdate();
		return "Stock Created Successfully...";
		
		
	}
	
//FirstStep	
	public String generateStockId() throws SQLException {
		connection = ConnectionHelper.getConnection();
		String stockId="";
		pst=connection.prepareStatement("SELECT CASE WHEN COUNT(STOCKID) IS NULL THEN 'S00'" + 
				"ELSE  CONCAT('S00',COUNT(STOCKID)+1) END stockid FROM Stock;");
		ResultSet rs = pst.executeQuery();
		rs.next();
		stockId = rs.getString("stockid");
		return stockId;
		
	}
	
	
	public int generateOrderId() throws SQLException {
		connection = ConnectionHelper.getConnection();
       int orderId= 0;
       pst=connection.prepareStatement("SELECT CASE WHEN MAX(ORDERID) IS NULL THEN 1" + 
      " ELSE MAX(ORDERID)+1 END OrderID FROM ORDERS");
       		
       ResultSet rs = pst.executeQuery();
       rs.next();
       orderId= rs.getInt("OrderID");

		return orderId;
       
}
   
       
	
}
