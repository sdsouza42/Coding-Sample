import java.util.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

class JFCChildTest{

	static class MainFrame extends JFrame{
	
		JButton timeButton = new JButton("Time");

		MainFrame(){
			super("Hello JFC");
			setSize(400, 400);
			setDefaultCloseOperation(EXIT_ON_CLOSE);
			setLayout(null);
			timeButton.setBounds(40, 40, 80, 25);
			timeButton.addActionListener(new ActionListener(){
				public void actionPerformed(ActionEvent e){
					Date now = new Date();
					//setTitle(now.toString());
					JOptionPane.showMessageDialog(MainFrame.this, now, "Hello JFC", JOptionPane.INFORMATION_MESSAGE, new ImageIcon("face.gif"));
				}
			});
			add(timeButton);
		}
	}

	public static void main(String[] args) throws Exception{
		MainFrame frame = new MainFrame();
		frame.setVisible(true);
	}
}

