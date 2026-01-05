use tao::{
    dpi::LogicalSize,
    event::{Event, WindowEvent},
    event_loop::{ControlFlow, EventLoop},
    window::WindowBuilder,
};

use wry::WebViewBuilder;

fn main() {
    let event_loop = EventLoop::new();

    let window = WindowBuilder::new()
        .with_title("Data's Books")
        .with_inner_size(LogicalSize::new(900.0, 600.0))
        .build(&event_loop)
        .unwrap();

    // index.html yolu
    let mut html_path = std::env::current_dir().unwrap();
    html_path.push("Data's Book on Demo/Lessons/Table Of Contents.html");

    // Windows uyumlu file:// URL
    let url = format!("file:///{}", html_path.to_string_lossy());

    let _webview = WebViewBuilder::new(&window)
        .with_url(&url)
        .build()
        .unwrap();

    event_loop.run(move |event, _, control_flow| {
        *control_flow = ControlFlow::Wait;

        if let Event::WindowEvent {
            event: WindowEvent::CloseRequested,
            ..
        } = event
        {
            *control_flow = ControlFlow::Exit;
        }
    });
}
