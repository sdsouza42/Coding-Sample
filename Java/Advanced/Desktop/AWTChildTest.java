import java.util.*;
import java.awt.*;
import java.awt.event.*;

class AWTChildTest{

	static class MainFrame extends Frame{

		Button timeButton = new Button("Time");

		MainFrame(){
			super("Hello AWT");
			setSize(400, 400);
			enableEvents(AWTEvent.WINDOW_EVENT_MASK);
			//add(timeButton, BorderLayout.SOUTH);
			//setLayout(new FlowLayout());
			setLayout(null);
			timeButton.setBounds(40, 40, 60, 25);
			timeButton.addActionListener(new ActionListener(){
				public void actionPerformed(ActionEvent e){
					Date now = new Date();
					setTitle(now.toString());
				}
			});
			add(timeButton);
		}

		@Override
		public void processWindowEvent(WindowEvent e){
			if(e.getID() == WindowEvent.WINDOW_CLOSING)
				System.exit(0);
			super.processWindowEvent(e);
		}
	}

	public static void main(String[] args) throws Exception{
		MainFrame frame = new MainFrame();
		frame.setVisible(true);
	}
}


