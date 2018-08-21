(function () {
    // Button type is Element
    let button: Element = document.querySelector('.btn');
    // Input type is HTMLInputElement
    let input: HTMLInputElement = <HTMLInputElement>document.querySelector('.form-control');
    // Heading tag is HTMLElement
    let heading: HTMLElement = document.querySelector('.headline') as HTMLElement;
    // Tuples allow for varying types
    let flexibleArray: [string, number, boolean] = ['John Doe', 24, true];
    // Enumerators
    enum Status { Started = 33, InProgress = 66, Completed = 100 }
    let status: Status = Status.InProgress;
    console.log("The project is ", status, "% completed.");
    button.addEventListener('click', handleButtonClick);
    // readonly modifier
    let settings: ScreenSettings = { width: 1920, height: 1080 };
    console.log("Display settings: ", settings);
})()

function handleButtonClick(evtObject: MouseEvent) {
    evtObject.preventDefault();
    let btn: Element = <Element>evtObject.target;
    console.log(btn.innerHTML);
}

interface ScreenSettings {
    readonly width: number;
    readonly height: number;
}