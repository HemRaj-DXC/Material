package com.dxc.inventory;

import java.sql.SQLException;
import java.util.Scanner;



public class PlaceOrderMain {
	public static void main(String[] args) {
		String stockId;
		int orderId,qtyOrd;
	
		Scanner sc = new Scanner(System.in);
	//	StockDAO dao = new StockDAO();
	//Stock order = new Stock();
	System.out.println("Enter stock Id ");
	stockId=sc.nextLine();
	System.out.println("Enter Quantity order");
    qtyOrd = sc.nextInt();
    StockDAO dao = new StockDAO();
	//	System.out.println("Enter Bill amount");
	//order.setBillAmt(Integer.parseInt(sc.nextLine()));
		try {
			Stock stockFound = dao.searchStock(stockId);
			if(stockFound!=null)
			{
				System.out.println(stockFound);
				System.out.println(dao.placeOrder(stockId,qtyOrd));
				
				
			}
			else {
				
				
				System.out.println("Stock does not exit");
			}
	
		}
		
		 catch (SQLException e) {
			// TODO Auto-generated catch block
		e.printStackTrace();
		}
	}
		
		
	}